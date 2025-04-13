import React from 'react';
import { Outlet } from 'react-router-dom';

function App() {
  return (
    <div>
      <header>
        <h1>ToDo App</h1>
      </header>
        <Outlet />
      <main>
        
      </main>
      <footer>
        <p>© 2025</p>
      </footer>
    </div>
  );
}

export default App;
