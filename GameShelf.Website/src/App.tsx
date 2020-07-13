import React, { useState } from 'react';
import { Route, Switch } from 'react-router-dom';
import Games from './Games';
import Users from './Users';
import About from './About';
import Home from './Home';
import Drawer from './Drawer';
import { makeStyles, createStyles, Theme } from '@material-ui/core/styles';
import { Toolbar } from '@material-ui/core'

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    container: {
      display: "flex"
    },
    root: {
      display: 'flex',
    },
    content: {
      flexGrow: 1,
      padding: theme.spacing(3),
    },
  })
)

function App() {
  const classes = useStyles();

  return (
    <div className={classes.container}>
      <div className={classes.root}>
        <Drawer />
        <main className={classes.content}>
          <Toolbar />
          <Switch>
            <Route exact from="/" render={() => <Home />} />
            <Route exact path="/about" render={() => <About />} />
            <Route exact path="/games" render={() => <Games />} />
            <Route exact path="/users" render={() => <Users />} />
          </Switch>
        </main>
      </div>
    </div>
  )
}

export default App;
