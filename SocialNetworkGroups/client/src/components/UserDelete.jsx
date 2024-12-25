import React, { useState } from 'react';
import api from '../api/api';

function UserDelete({ id, onDeleteSuccess }) {
    const [message, setMessage] = useState('');

    const handleDelete = async () => {
        try {
            await api.delete(`/User/${id}`);
            onDeleteSuccess(id);
            setMessage('User deleted successfully!');
        } catch (error) {
            console.error('Error deleting user:', error);
            setMessage('Failed to delete user');
        }
    };

    return (
        <div>
            {message && (
                <div className={`alert ${message.includes('Failed') ? 'alert-danger' : 'alert-success'}`} role="alert">
                    {message}
                </div>
            )}
            <button onClick={handleDelete} className="btn btn-danger btn-sm">
                Delete
            </button>
        </div>
    );
}

export default UserDelete;