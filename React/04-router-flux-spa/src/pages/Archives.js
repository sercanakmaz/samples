import React from 'react';
import queryString from 'query-string'

export default class Archives extends React.Component {
    render() {
        const query = queryString.parse(this.props.location.search);

        const { match } = this.props;
        const { article } = match.params;
        const { date, filter } = query;

        return (
            <div className="row">
                <div className="col-md-4">
                    <h1>Archives ({article})</h1>
                    <h4>date: {date}, filter: {filter}</h4>
                </div>
            </div>
        );
    }
}
