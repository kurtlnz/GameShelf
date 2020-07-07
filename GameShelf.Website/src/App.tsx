import './App.css';
import React, { useState } from 'react';
import Games from './Games';

function App() {
  const [games, setGames] = useState([
    { title: "Settlers of Catan", year: 1997 },
    { title: "Carcassonne", year: 2001 },
    { title: "Splendor", year: 2014 },
  ])

  return (
    <div className="app">
      <Games />
    </div>
  )
}

export default App;
