import React, { useEffect, useState } from 'react';
import axios from 'axios';
import BowlingHeading from './components/BowlingHeading';
import BowlerTable from './components/BowlerTable';
import type { Bowler } from './types/Bowler';

function App() {
    // list from the api empty until the first request finishes
    const [bowlers, setBowlers] = useState<Bowler[]>([]);
    const [loading, setLoading] = useState<boolean>(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        // vite dev server forwards api requests to the aspnet backend on port 5088
        const fetchBowlers = async () => {
            try {
                const response = await axios.get('/api/bowler');
                setBowlers(response.data);
                setLoading(false);
            } catch (err) {
                setError('Failed to fetch bowlers');
                setLoading(false);
                console.error('Error fetching bowlers:', err);
            }
        };

        fetchBowlers();
    }, []);

    if (loading) {
        return (
            <div style={{ 
                textAlign: 'center', 
                marginTop: '50px',
                fontSize: '1.2rem',
                color: '#666'
            }}>
                Loading bowlers...
            </div>
        );
    }

    if (error) {
        return (
            <div style={{ 
                textAlign: 'center', 
                marginTop: '50px', 
                color: 'red',
                fontSize: '1.2rem'
            }}>
                {error}
            </div>
        );
    }

    return (
        <div className="App">
            <BowlingHeading />
            {bowlers.length > 0 ? (
                <BowlerTable bowlers={bowlers} />
            ) : (
                <p style={{ 
                    textAlign: 'center',
                    marginTop: '30px',
                    fontSize: '1.1rem',
                    color: '#666'
                }}>
                    No bowlers found from Marlins or Sharks teams.
                </p>
            )}
        </div>
    );
}

export default App;
