import React from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';

// import createHistory from 'history/createBrowserHistory';

import Archives from './Archives';
import Featured from './Todos';
import Settings from './Settings';
import Footer from '../components/layout/Footer';
import Nav from '../components/layout/Nav';

export default class Layout extends React.Component {
    render() {
        const {location} = this.props.history;
        const containerStyle = {
            marginTop: "60px"
        };

        return (
            <Router>
                <div>
                    <Nav location={location}/>
                    <div className="container" style={containerStyle}>
                        <div className="row">
                            <div className="col-lg-12">
                                <h1>KillerNew.net</h1>
                                <Route exact path="/" component={Featured} />
                                <Route path="/archives/:article?" component={Archives} />
                                <Route path="/settings" component={Settings} />
                            </div>
                        </div>
                        <Footer/>
                    </div>
                </div>
            </Router>
        );
    }
}
