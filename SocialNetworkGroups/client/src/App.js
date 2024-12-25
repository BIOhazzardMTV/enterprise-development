import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import UserCreate from './components/UserCreate';
import UserDelete from './components/UserDelete';
import UserList from './components/UserList';
import UserUpdate from './components/UserUpdate';

function App() {
    return (
        <Router>
            <div>
                <h1 className="text-center">User Client</h1>
                <Routes>
                    <Route path="/" element={<UserList />} />
                    <Route path="/User/create" element={<UserCreate />} />
                    <Route path="/User/update/:id" element={<UserUpdate />} />
                    <Route path="/User/delete/:id" element={<UserDelete />} />
                </Routes>
            </div>
        </Router>
    );
}

export default App;
