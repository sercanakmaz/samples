import React from 'react';
import ReactDOM from 'react-dom';
import createHistory from 'history/createBrowserHistory';

import Layout from './pages/Layout';

import registerServiceWorker from './registerServiceWorker';

ReactDOM.render(<Layout history={createHistory()}/>
    , document.getElementById('app'));

// ReactDOM.render(
//     <Router>
//         <Layout history={createHistory()}>
//             <Route path="/featured" component={Featured} />
//             <Route path="/archives/:article?" component={Archives} />
//             <Route path="/settings" component={Settings} />
//         </Layout>
//     </Router>
//     , document.getElementById('app'));

// ReactDOM.render(
//     <Layout>
//     </Layout>
//     , document.getElementById('app'));

registerServiceWorker();
