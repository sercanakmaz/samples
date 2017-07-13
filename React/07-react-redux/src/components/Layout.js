import React from 'react';
import { connect } from 'react-redux'

import { fetchUser } from '../actions/userActions'
import { fetchTweets } from '../actions/tweetsActions'

class Layout extends React.Component {
    componentWillMount() {
        this.props.dispatch(fetchUser())
    }
    fetchTweets() {
        this.props.dispatch(fetchTweets())
    }
    render() {
        const { user, tweets } = this.props;
        const mappedTweets = tweets.map(tweet => <li>{tweet.text}</li>)
        
        return <div>
            <button onClick={this.fetchTweets.bind(this)}>load tweets</button>
            <h1>{user.name}</h1>
            <ul>
                {mappedTweets}
            </ul>
        </div>
    }
}

export default connect((store) => {
    return {
        user: store.user.user,
        tweets: store.tweets.tweets,
        userFetched: store.user.fetched
    }
})(Layout)