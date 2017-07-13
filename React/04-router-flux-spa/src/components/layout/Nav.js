import React from 'react';
import { NavLink } from 'react-router-dom';

export default class Nav extends React.Component {
    constructor() {
        super();
        this.state = {
            collapsed: true
        };
    }
    toggleCollapse() {
        const collapsed = !this.state.collapsed;
        this.setState({ collapsed });
    }
    render() {
        const { location } = this.props;
        const { collapsed } = this.state;
        const featuredClass = location.pathname === '/' ? 'active' : '';
        const archiveClass = location.pathname.match(/^\/archives/) ? 'active' : '';
        const settingsClass = location.pathname.match(/^\/featured/) ? 'active' : '';
        const navClass = collapsed ? "collapse" : "";

        return (
            <nav className="navbar navbar-inverse navbar-fixed-top">
                <div className="container">
                    <div className="navbar-header">
                        <button type="button" className="navbar-toggle" onClick={this.toggleCollapse.bind(this)}>
                            <span className="sr-only">Toggle navigation</span>
                            <span className="icon-bar"></span>
                            <span className="icon-bar"></span>
                            <span className="icon-bar"></span>
                        </button>
                    </div>
                    <div className={"navbar-collapse " + navClass} id="bs-example-navbar-collapse-1">
                        <ul className="nav navbar-nav">
                            <li className={featuredClass}>
                                <NavLink to="/" onClick={this.toggleCollapse.bind(this)}>Featured</NavLink>
                            </li>
                            <li className={archiveClass}>
                                <NavLink to="/archives" onClick={this.toggleCollapse.bind(this)}>Archives</NavLink>
                            </li>
                            <li className={settingsClass}>
                                <NavLink to="/settings" onClick={this.toggleCollapse.bind(this)}>Settings</NavLink>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        );
    }
}
