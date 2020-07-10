import React, { useState } from 'react';
import { Route, Switch } from 'react-router-dom';
import Games from './Games';
import Users from './Users';
import About from './About';
import Home from './Home';
import Drawer from './Drawer';
import { makeStyles } from '@material-ui/core/styles';

const useStyles = makeStyles({
  container: {
    display: "flex"
  }
})

function App() {
  const classes = useStyles();

  return (
    <div className={classes.container}>
      <Drawer />
      <Switch>
        <Route exact from="/" render={() => <Home />} />
        <Route exact path="/about" render={() => <About />} />
        <Route exact path="/games" render={() => <Games />} />
        <Route exact path="/users" render={() => <Users />} />
      </Switch>
    </div>
  )
}

export default App;
