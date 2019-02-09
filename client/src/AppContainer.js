import React, {Component} from 'react';

const AppContext = React.createContext();

export default class AppContainer extends Component {
    render() {
        return (
            //TODO: Put the context api actions parameter here
            <AppContext.Provider value = {{
                state: this.state,
                actions: {
                    //TODO: Put functions here
                }
            }}>
                {...children}
            </AppContext.Provider>
        );
    }
}