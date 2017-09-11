//import {computedFrom} from 'aurelia-framework';

export class Welcome {
  heading = 'Welcome to the Aurelia Weather App!';
  firstName = 'John';
  lastName = 'Doe';
  previousValue = this.fullName;

  //Getters can't be directly observed, so they must be dirty checked.
  //However, if you tell Aurelia the dependencies, it no longer needs to dirty check the property.
  //To optimize by declaring the properties that this getter is computed from, uncomment the line below
  //as well as the corresponding import above.
  //@computedFrom('firstName', 'lastName')
  get fullName() {
    return `${this.firstName} ${this.lastName}`;
  }

  submit() {
    this.previousValue = this.fullName;
    alert(`Welcome, ${this.fullName}!`);
  }

  canDeactivate() {
    if (this.fullName !== this.previousValue) {
      return confirm('Are you sure you want to leave?');
    }
  }

  cities = [
    { name: 'Buenos Aires/Argentina', value: { latitude: -34.603684, longtude: -58.381559 } },
    { name: 'Lima/Peru', value: { latitude: -12.046373, longtude: -77.042754 } },
    { name: 'New York/United States Of America', value: { latitude: 40.712784, longtude: -74.005941 } },
    { name: 'Paris/France', value: { latitude: 48.856614, longtude: 2.352222 } },
    { name: 'Toronto/Canada', value: { latitude: 43.653226, longtude: -79.383184 } }
  ];

  forecastProviders = [
    { name: 'DarkSky.net', alias: 'DarkSky' },
    { name: 'WeatherUnderground.com', alias: 'WUnderground' }
  ];
}

export class UpperValueConverter {
  toView(value) {
    return value && value.toUpperCase();
  }
}
