import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import api from '../api/api';

const UserCreate = () => {
    const [FullName, setFullName] = useState('');
    const [Gender, setGender] = useState('');
    const [DateOfBirth, setDateOfBirth] = useState('');
    const [RegistrationDate, setRegistrationDate] = useState('');
    const [message, setMessage] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await api.post('/User', { FullName, Gender, DateOfBirth, RegistrationDate });
            setMessage('User created successfully!');
            setTimeout(() => {
                navigate('/');
            }, 1000);
        } catch (error) {
            console.error('Error creating user:', error);
            setMessage(`Failed to create user: ${error.response?.data || error.message}`);
        }
    };

    return (
        <div className="container mt-5">
            <h2>Create User</h2>
            {message && (
                <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
                    {message}
                </div>
            )}
            <form onSubmit={handleSubmit}>
                <div className="mb-3">
                    <label htmlFor="FullName" className="form-label">Full Name:</label>
                    <input
                        type="text"
                        className="form-control"
                        id="FullName"
                        value={FullName}
                        onChange={(e) => setFullName(e.target.value)}
                        required
                        maxLength={200}
                    />
                </div>
                <div className="mb-3">
                    <label htmlFor="Gender" className="form-label">Gender:</label>
                    <input
                        type="text"
                        className="form-control"
                        id="Gender"
                        value={Gender}
                        onChange={(e) => setGender(e.target.value)}
                        required
                        maxLength={7}
                    />
                </div>
                <div className="mb-3">
                    <label htmlFor="DateOfBirth" className="form-label">DateOfBirth:</label>
                    <input
                        type="text"
                        className="form-control"
                        id="DateOfBirth"
                        value={DateOfBirth}
                        onChange={(e) => setDateOfBirth(e.target.value)}
                        required
                        maxLength={11}
                    />
                </div>
                <div className="mb-3">
                    <label htmlFor="RegistrationDate" className="form-label">RegistrationDate:</label>
                    <input
                        type="text"
                        className="form-control"
                        id="RegistrationDate"
                        value={RegistrationDate}
                        onChange={(e) => setRegistrationDate(e.target.value)}
                        required
                        maxLength={11}
                    />
                </div>
                <button type="submit" className="btn btn-primary">Create</button>
            </form>
        </div>
    );
}

export default UserCreate;