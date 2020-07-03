import './App.css';
import React, { useState } from 'react';
import GameTable from './GameTable';

function App() {
  const [games, setGames] = useState([
    { title: "Settlers of Catan", year: 1997 },
    { title: "Carcassonne", year: 2001 },
    { title: "Splendor", year: 2014 },
  ])

  return (
    <div className="app">
      <GameTable />
    </div>
  )
}

export default App;
