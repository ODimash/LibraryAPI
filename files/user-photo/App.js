import React, { useEffect, useState } from 'react';
import GameBoard from './GameBoard';
import PlayerInput from './PlayerInput';
import IntroPage from './IntroPage'; // Вступительная страница

function App() {
  const [players, setPlayers] = useState([]);
  const [currentPlayer, setCurrentPlayer] = useState(0);
  const [gameStarted, setGameStarted] = useState(false);
  const [showIntro, setShowIntro] = useState(false); // Управляем показом вступительной страницы

  const shufflePlayers = (playerList) => {
    return playerList
      .map((player) => ({ ...player, sortKey: Math.random() }))
      .sort((a, b) => a.sortKey - b.sortKey)
      .map(({ sortKey, ...rest }) => rest); // Удаляем вспомогательный ключ
  };

  const startGame = () => setGameStarted(true);

  const handleStartGame = (enteredPlayers) => {
    const shuffledPlayers = shufflePlayers(enteredPlayers);
    setPlayers(shuffledPlayers);
    setShowIntro(true); // Переход на вступительную страницу
  };

  const nextPlayer = () => {
    setCurrentPlayer((prev) => (prev + 1) % players.length);
  };

  return (
    <div>
      {!players.length ? (
        <PlayerInput startGame={handleStartGame} />
      ) : showIntro ? (
        <IntroPage onGameStart={startGame} setShowIntro={setShowIntro} />
      ) : (
        <GameBoard
          players={players}
          setPlayers={setPlayers}
          currentPlayer={currentPlayer}
          nextPlayer={nextPlayer}
        />
      )}
    </div>
  );
}

export default App;
