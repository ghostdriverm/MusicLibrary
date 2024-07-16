import React from 'react';
import { Link } from 'react-router-dom';
import SearchBar from './SearchBar';

const Navbar = () => {
    return (
        <nav className="navigation">
            <div className="navigation-bar">
                <div className="navigation-title">Digital music library</div>
                <SearchBar />
                <div className="navigation-items">
                    <div className="navigation-item">
                        <Link to="/">Home</Link>
                    </div>
                    <div className="navigation-item">
                        <Link to="/artists">Artists</Link>
                    </div>
                </div>
            </div>
        </nav>
    );
};

export default Navbar;