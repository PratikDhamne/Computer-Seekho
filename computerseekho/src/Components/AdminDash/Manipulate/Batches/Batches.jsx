import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import EditBatch from './EditBatch'; // Ensure this path is correct
/* import './BatchCRUD.css'; */

const Batches = () => {
  const [batches, setBatches] = useState([]);
  const [editingBatch, setEditingBatch] = useState(null);
  const [isEditing, setIsEditing] = useState(false);
  const navigate = useNavigate();

  // Fetch batches from the API
  useEffect(() => {
    const fetchBatches = async () => {
      try {
        const response = await fetch('http://localhost:5051/api/Batch');
        const data = await response.json();
        setBatches(data);
        console.log(data)
      } catch (error) {
        console.error('Error fetching batches:', error);
      }
    };

    fetchBatches();
  }, []);

  // Handle edit batch
  const handleEdit = (batchId) => {
    const batchToEdit = batches.find(batch => batch.batch_id === batchId);
    setEditingBatch(batchToEdit);
    setIsEditing(true);
  };

  // Handle create batch
  const handleCreate = () => {
    navigate('/create-batch');
  };

  // Handle update batch
  const handleUpdate = () => {
    // Fetch updated batches
    fetch('http://localhost:5051/api/Batch')
      .then(response => response.json())
      .then(data => setBatches(data))
      .catch(error => console.error('Error fetching updated batches:', error));
  };

  // Handle close edit form
  const handleCloseEdit = () => {
    setIsEditing(false);
    setEditingBatch(null);
  };

  return (
    <div className="batch-crud-container">
      <h1>Batch Management</h1>
      <button onClick={handleCreate}>Create New Batch</button>

      {/* Show EditBatch component if editing */}
      {isEditing && (
        <EditBatch
          batch={editingBatch}
          onUpdate={handleUpdate}
          onClose={handleCloseEdit}
        />
      )}

      <table>
        <thead>
          <tr>
            <th>Batch Name</th>
            <th>Start Date</th>
            <th>End Date</th>
            <th>Course</th>
            <th>Final Presentation Date</th>
            <th>Fees</th>
            <th>Fees From</th>
            <th>Fees To</th>
            <th>Active</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {batches.map(batch => (
            <tr key={batch.batchId}>
              <td>{batch.batchName}</td>
              <td>{new Date(batch.batchStartDate).toLocaleDateString()}</td>
              <td>{new Date(batch.batchEndDate).toLocaleDateString()}</td>
              <td>{batch.course_id?.courseName || 'N/A'}</td>
              <td>{new Date(batch.finalPresentationDate).toLocaleDateString()}</td>
              <td>₹{batch.batchFees.toFixed(2)}</td>
              <td>{new Date(batch.courseFeesFrom).toLocaleDateString()}</td>
              <td>{new Date(batch.courseFeesTo).toLocaleDateString()}</td>
              <td>{batch.batchIsActive ? 'Yes' : 'No'}</td>
              <td>
                <button onClick={() => handleEdit(batch.batchId)}>Edit</button>
                {/* Implement delete functionality if needed */}
                {/* <button onClick={() => handleDelete(batch.batch_id)}>Delete</button> */}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Batches;
