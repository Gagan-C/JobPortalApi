import React, { useState } from 'react';
import axios from 'axios';

const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [message, setMessage] = useState('');

    const handleLogin = async (e) => {
        e.preventDefault();
        try {
            const response = await axios.post('https://localhost:7260/login', 
                { email, password },
                {
                    params: {
                        useCookie: true,
                        useSessionCookies: true
                    },
                    headers: {
                        'Accept': '*/*',
                        'Content-Type': 'application/json',
                        'Access-Control-Allow-Origin': 'http://localhost:33829'
                    },
                    withCredentials: true
                }
            );
            console.log(response);
            if (response.status !== 200) {
                throw new Error('Login failed');
            }
            setMessage('Login successful');
            setError('');
        } catch (err) {
            setError('Login failed. Please check your credentials and try again. ' + err.message);
        }
    };

    const handleLogout = async () => {
        try {
            const response = await axios.post('https://localhost:7260/logout', {}, {
                withCredentials: true,
                headers: {
                    'Accept': '*/*',
                    'Content-Type': 'application/json'
                }
            });
            console.log(response);
            if (response.status !== 200) {
                throw new Error('Logout failed');
            }
            setMessage('Logout successful');
            setError('');
            setEmail('');
            setPassword('');
        } catch (err) {
            setError('Logout failed. Please try again. ' + err.message);
        }
    };

    return (
        <div>
            <h2>Login</h2>
            <form onSubmit={handleLogin}>
                <div>
                    <label>Email:</label>
                    <input
                        type="text"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Password:</label>
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>
                {error && <p style={{ color: 'red' }}>{error}</p>}
                {message && <p style={{ color: 'green' }}>{message}</p>}
                <button type="submit">Login</button>
            </form>
            <button onClick={handleLogout}>Logout</button>
        </div>
    );
};

export default Login;
