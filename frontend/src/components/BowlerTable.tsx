import React from 'react';
import type { Bowler } from '../types/Bowler';

interface BowlerTableProps {
    bowlers: Bowler[];
}

const BowlerTable: React.FC<BowlerTableProps> = ({ bowlers }) => {
    return (
        <div style={{ margin: '20px', overflowX: 'auto' }}>
            <table style={{ 
                width: '100%', 
                borderCollapse: 'collapse',
                boxShadow: '0 2px 8px rgba(0,0,0,0.1)'
            }}>
                <thead style={{ 
                    backgroundColor: '#f2f2f2',
                    borderBottom: '2px solid #ddd'
                }}>
                    <tr>
                        <th style={tableHeaderStyle}>Bowler Name</th>
                        <th style={tableHeaderStyle}>Team</th>
                        <th style={tableHeaderStyle}>Address</th>
                        <th style={tableHeaderStyle}>City</th>
                        <th style={tableHeaderStyle}>State</th>
                        <th style={tableHeaderStyle}>Zip</th>
                        <th style={tableHeaderStyle}>Phone</th>
                    </tr>
                </thead>
                <tbody>
                    {bowlers.map((bowler, index) => (
                        <tr key={index} style={{ 
                            borderBottom: '1px solid #ddd',
                            backgroundColor: index % 2 === 0 ? '#fff' : '#f9f9f9'
                        }}>
                            <td style={tableCellStyle}>{bowler.bowlerFullName}</td>
                            <td style={tableCellStyle}>{bowler.teamName}</td>
                            <td style={tableCellStyle}>{bowler.address}</td>
                            <td style={tableCellStyle}>{bowler.city}</td>
                            <td style={tableCellStyle}>{bowler.state}</td>
                            <td style={tableCellStyle}>{bowler.zip}</td>
                            <td style={tableCellStyle}>{bowler.phoneNumber}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

const tableHeaderStyle: React.CSSProperties = {
    padding: '12px',
    textAlign: 'left',
    fontWeight: 'bold'
};

const tableCellStyle: React.CSSProperties = {
    padding: '12px',
    textAlign: 'left'
};

export default BowlerTable;