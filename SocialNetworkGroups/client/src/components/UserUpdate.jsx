import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import api from '../api/api';

const UserUpdate = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [FullName, setFullName] = useState('');
    const [Gender, setGender] = useState('');
    const [DateOfBirth, setDateOfBirth] = useState('');
    const [RegistrationDate, setRegistrationDate] = useState('');
    const [message, setMessage] = useState('');
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchUser = async () => {
            try {
                const response = await api.get(`/User/${id}`);
                setFullName(response.data.FullName);
                setGender(response.data.Gender);
                setDateOfBirth(response.data.DateOfBirth);
                setRegistrationDate(response.data.RegistrationDate);
            } catch (error) {
                console.error('Error fetching user:', error);
                setError('User not found');
            }
        };

        fetchUser();
    }, [id]);

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await api.put(`/User/${id}`, { FullName, Gender, DateOfBirth, RegistrationDate });
            setMessage('User updated successfully!');
            setTimeout(() => {
                navigate('/');
            }, 1000);
        } catch (error) {
            console.error('Error updating user:', error);
            setMessage(`Failed to update user: ${error.response?.data || error.message}`);
        }
    };

    return (
        <div className="container mt-5">
            <h2>Update User</h2>
            {message && (
                <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
                    {message}
                </div>
            )}
            {error && (
                <div className="alert alert-danger" role="alert">
                    {error}
                </div>
            )}
            {!error && (
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
                    <button type="submit" className="btn btn-primary">Update User</button>
                </form>
            )}
        </div>
    );
};

export default UserUpdate;