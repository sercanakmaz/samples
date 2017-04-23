/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 * @flow
 */

import React, { Component } from 'react';
import { AppRegistry, StyleSheet, ListView, Text, View, Image } from 'react-native';

export default class HelloWorld extends Component {
    constructor(props) {
    super(props);
    const ds = new ListView.DataSource({rowHasChanged: (r1, r2) => r1 !== r2});
    this.state = {
      dataSource: ds.cloneWithRows([
        {
          title: "Sarı küçük kedicik",
          type: "Kedi",
          location: "Istanbul, Turkey",
          imageSource: "http://www.bempar.com/Uploads/Product/Images/25kuyl1p-340x260.jpg",
          description: "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua...."
        },
        {
          title: "Yavru kangal köpecik",
          type: "Köpek",
          location: "Istanbul, Turkey",
          imageSource: "http://www.bempar.com/Uploads/Product/Images/o0wroql1-340x260.jpg",
          description: "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua...."
        }
      ])
    };
  }
  render() {
   return (
      <View style={{flex: 1, paddingTop: 22}}>
        <ListView
          dataSource={this.state.dataSource}
          renderRow={(rowData) => 
            <View style={{flexDirection: "row"}}>
              <Text style={{flex:2}}>{rowData.title}</Text>
              <Image
                  resizeMode="contain"
                  style={{width: 50, height: 50}}
                  source={{ uri: rowData.imageSource}}
                />
              <Text style={{flex:1}}>{rowData.type}</Text>
              <Text style={{flex:1}}>{rowData.location}</Text>
            </View>}
        />
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: '#F5FCFF',
  },
  welcome: {
    fontSize: 20,
    textAlign: 'center',
    margin: 10,
  },
  instructions: {
    textAlign: 'center',
    color: '#333333',
    marginBottom: 5,
  },
});

AppRegistry.registerComponent('HelloWorld', () => HelloWorld);
