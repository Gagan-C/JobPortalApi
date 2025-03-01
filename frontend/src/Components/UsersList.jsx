import React, { useState } from 'react';
import axios from 'axios';

const UsersList = () => {
    const [users, setUsers] = useState([]);
    const [error, setError] = useState('');

    const fetchUsers = async () => {
        try {
            const response = await axios.get('https://localhost:7260/api/User', {
                withCredentials: true,
                params: {
                    useCookie: true,
                    useSessionCookies: true
                },
                headers: {
                    'Accept': '*/*',
                    'Content-Type': 'application/json'
                },
            });
            console.log(response);
            setUsers(response.data);
            setError('');
        } catch (err) {
            console.error('Fetch error:', err);
            setUsers([]);
            setError('Failed to fetch users. Please try again later. ' + err.message);
        }
    };

    return (
        <div>
            <h2>Users List</h2>
            <button onClick={fetchUsers}>Fetch Users</button>
            {error && <p style={{ color: 'red' }}>{error}</p>}
            {users.length > 0 && (
                <table>
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Name</th>
                            <th>Email</th>
                        </tr>
                    </thead>
                    <tbody>
                        {users.map(user => (
                            <tr key={user.id}>
                                <td>{user.id}</td>
                                <td>{user.username}</td>
                                <td>{user.email}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            )}
        </div>
    );
};

export default UsersList;
