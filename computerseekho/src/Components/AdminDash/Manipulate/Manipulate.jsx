import React, { useState } from 'react';
import './Manipulate.css';
import Header from '../../AdminDash/Header/Navbar';
import Staff from '../Manipulate/Staff/Staff';
import Images from './Images/ImagesUpload';
import Albums from '../Manipulate/Albums/Albums';
import Courses from '../Manipulate/Courses/Courses';
import Batches from '../Manipulate/Batches/Batches';
import Videos from '../Manipulate/Videos/Videos';

const Manipulate = () => {
  const [selectedComponent, setSelectedComponent] = useState('Staff');

  const renderSelectedComponent = () => {
    switch (selectedComponent) {
      case 'Staff':
        return <Staff />;
      case 'Images':
        return <Images />;
      case 'Albums':
        return <Albums />;
      case 'Videos':
        return <Videos />;
      case 'Courses':
        return <Courses />;
      case 'Batches':
        return <Batches />;
      default:
        return <p>Please select a component from the sub-navbar.</p>;
    }
  };

  return (
    <div className="manipulate-container">
      <Header />
      <br/><br/>
      <div className="sub-navbar">
        <button onClick={() => setSelectedComponent('Staff')}>Staff</button>
        <button onClick={() => setSelectedComponent('Images')}>Images</button>
        <button onClick={() => setSelectedComponent('Albums')}>Albums</button>
        <button onClick={() => setSelectedComponent('Videos')}>Videos</button>
        <button onClick={() => setSelectedComponent('Courses')}>Courses</button>
        <button onClick={() => setSelectedComponent('Batches')}>Batches</button>
      </div>
      <div className="component-container">
        {renderSelectedComponent()}
      </div>
    </div>
  );
};

export default Manipulate;
