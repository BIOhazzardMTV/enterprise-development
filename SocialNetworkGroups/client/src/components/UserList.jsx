import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import api from '../api/api';
import UserDelete from './UserDelete';

const UserList = () => {
    const [Users, setUsers] = useState([]);
    const [message, setMessage] = useState('');

    const handleDeleteSuccess = (id) => {
        setUsers(Users.filter((User) => User.id !== id));
    };

    useEffect(() => {
        const fetchUsers = async () => {
            try {
                const response = await api.get('/User');
                setUsers(response.data);
            } catch (error) {
                console.error('Error fetching users:', error);
                setMessage('Failed to fetch users.');
                setTimeout(() => setMessage(''), 3000);
            }
        };
        fetchUsers();
    }, []);

    return (
        <div className="container mt-5">
            <h2>User List</h2>
            {message && (
                <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
                    {message}
                </div>
            )}
            <Link to="/User/create" className="btn btn-success mb-3">Create New User</Link>
            <ul className="list-group">
                {Users.length > 0 ? (
                    Users.map((User) => (
                        <li key={User.id} className="list-group-item d-flex justify-content-between align-items-center">
                            <div>
                                <p><strong>FullName:</strong> {User.FullName}</p>
                                <p><strong>Gender:</strong> {User.Gender}</p>
                                <p><strong>DateOfBirth:</strong> {User.phone}</p>
                                <p><strong>RegistrationDate:</strong> {User.RegistrationDate}</p>
                            </div>
                            <div>
                                <Link to={`/User/update/${User.id}`} className="btn btn-warning btn-sm me-2">Update</Link>
                                <UserDelete id={User.id} onDeleteSuccess={handleDeleteSuccess} />
                            </div>
                        </li>
                    ))
                ) : (
                    <li className="list-group-item">No users found</li>
                )}
            </ul>
        </div>
    );
}

export default UserList;