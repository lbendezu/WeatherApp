//import {computedFrom} from 'aurelia-framework';
import { inject } from 'aurelia-framework';
import { HttpClient } from 'aurelia-fetch-client';
import 'fetch';

@inject(HttpClient)
export class Welcome {
  heading = 'Welcome to the Aurelia Weather App!';
  forecast = {};
  selectedCity = null;
  selectedProvider = null;
  isCelsius = true;

  constructor(http) {
    http.configure(config => {
      config
        .useStandardConfiguration()
        .withBaseUrl('/');
    });

    this.http = http;

  }

  submit() {
    this.previousValue = this.fullName;
    alert(`Welcome, ${this.fullName}!`);
  }

  getForecast() {
    let provider = this.selectedProvider.alias;
    let latitude = this.selectedCity.value.latitude;
    let longitude = this.selectedCity.value.longitude;
    this.http.fetch('forecast/get?provider=' + provider + '&latitude=' + latitude + '&longitude=' + longitude)
      .then(response => response.json())
      .then(forecast => this.forecast = forecast);
  }

  checkScale() {
    console.log(this.selectedScale);
    if (this.selectedScale.value == 'Celsius') {
      this.isCelsius = true;
    }      
    else{
      this.isCelsius = false;
    }      
  }

  cities = [
    { name: 'Buenos Aires/Argentina', value: { latitude: -34.603684, longitude: -58.381559 } },
    { name: 'Lima/Peru', value: { latitude: -12.046373, longitude: -77.042754 } },
    { name: 'New York/United States Of America', value: { latitude: 40.712784, longitude: -74.005941 } },
    { name: 'Paris/France', value: { latitude: 48.856614, longitude: 2.352222 } },
    { name: 'Toronto/Canada', value: { latitude: 43.653226, longitude: -79.383184 } }
  ];

  forecastProviders = [
    { name: 'DarkSky.net', alias: 'DarkSky' },
    { name: 'WeatherUnderground.com', alias: 'WeatherUnderground' }
  ];

  scales = [
    { name: 'Celsius', value: 'Celsius' },
    { name: 'Fahrenheit', value: 'Fahrenheit' }    
  ];
}

export class UpperValueConverter {
  toView(value) {
    return value && value.toUpperCase();
  }
}
