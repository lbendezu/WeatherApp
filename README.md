# WeatherApp

This is a demo with aurelia.

Pre-requisites
--------------

In order to run this project we will need the following installed:

* [Python v2](https://www.python.org/downloads/) (Make sure to install version 2)
* [Node.js](https://nodejs.org/en/)
* [npm](https://github.com/felixrieseberg/npm-windows-upgrade)
* [Git](https://git-scm.com/)

After that we need to install globally some required packages in order for Aurelia to run (using cmd):

* Gulp
```
npm install -g gulp
```
* jspm
```
npm install -g jspm
```

Last but not least, we need to install node-gyp which will help us to build the Aurelia project

* [node-gyp](https://github.com/nodejs/node-gyp)


Getting started
----------------

After we have downloaded the repository and build the solution we will need to run the following (using cmd) in the Aurelia folder (WeatherApp/WeatherApp/Aurelia/):

```
npm install
```

```
jspm install -y
```

Finally, we will need to start the watcher in the same location (WeatherApp/WeatherApp/Aurelia/):

```
gulp watch
```

Then we will be able to start the app using Visual Studio
