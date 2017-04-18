import React, { Component } from 'react';
import {
  AppRegistry,
  StyleSheet,
  Text,
  TextInput,
  Image,
  View,
  Button,
  Alert,
  TouchableHighlight
} from 'react-native';

class CustomButton extends Component{
  render(){
    return (
        <TouchableHighlight onPress={onPress}>
          <Text>Button Element</Text>
        </TouchableHighlight>
    );
  }
}