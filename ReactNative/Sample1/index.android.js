/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 * @flow
 */

import React, { Component } from 'react';
import {
  AppRegistry,
  StyleSheet,
  Text,
  TextInput,
  Image,
  View
} from 'react-native';
import LinearGradient from 'react-native-linear-gradient';
import { COLOR, ThemeProvider, Button } from 'react-native-material-ui';

const uiTheme = {
    palette: {
        primaryColor: COLOR.green500,
    },
    toolbar: {
        container: {
            height: 50,
        },
    },
};


export default class Sample1 extends Component {
  render() {
    return (
        <ThemeProvider uiTheme={uiTheme}>
          <LinearGradient colors={['#a4c639', '#63bcb8']} style={styles.linearGradient}>
            <Image
                resizeMode="contain"
                style={styles.logo}
                source={require('./assets/img/logo.png')}
              />
            <TextInput
                placeholder="TC Kimlik No"
                style={{height: 40, 
                        width: '75%',
                        alignContent: 'center',
                        alignSelf: 'center'}}
              />
            <Button raised primary text="Primary" />

          </LinearGradient>
        </ThemeProvider>
    );
  }
}

const styles = StyleSheet.create({
  logo: {
     flex: 3,
     maxWidth: 445,
     maxHeight: 264,
     width: '50%',
     alignContent: 'center',
     alignSelf: 'center'
  },
  linearGradient: {
    flex:1,
    borderWidth: 4
  },
});

AppRegistry.registerComponent('Sample1', () => Sample1);
