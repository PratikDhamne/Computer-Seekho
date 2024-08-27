import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import './Staff.css';

// A helper function to fetch data
const fetchData = async (endpoint) => {
  const response = await fetch(endpoint);
  if (!response.ok) {
    throw new Error('Network response was not ok');
  }
  return response.json();
};

const Staff = () => {
  const [staff, setStaff] = useState([]);
  const [loading, setLoading] = useState(true);
  const [editingStaff, setEditingStaff] = useState(null);

  useEffect(() => {
    const fetchStaff = async () => {
      try {
        const staffData = await fetchData('http://localhost:5051/api/Staffs');
        setStaff(staffData);
        console.log(staffData);
      } catch (error) {
        console.error('Error fetching staff data:', error);
      } finally {
        setLoading(false);
      }
    };

    fetchStaff();
  }, []);

  const handleEditStaff = (staff) => {
    setEditingStaff(staff);
  };

  const handleUpdateStaff = async () => {
    try {
      const response = await fetch(`http://localhost:5051/api/Staffs/${editingStaff.staff_id}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(editingStaff),
      });

      if (response.ok) {
        const updatedStaff = await response.json();
        setStaff((prev) => prev.map((staff) => (staff.staffId === updatedStaff.staffId ? updatedStaff : staff)));
        setEditingStaff(null);
      }
    } catch (error) {
      console.error('Error updating staff:', error);
    }
  };

  const handleDeleteStaff = async (id) => {
    try {
      const response = await fetch(`http://localhost:5051/api/Staffs/${id}`, {
        method: 'DELETE',
      });

      if (response.ok) {
        setStaff((prev) => prev.filter((staff) => staff.staffId !== id));
      }
    } catch (error) {
      console.error('Error deleting staff:', error);
    }
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="staff-crud-container">
      <h2>Staff</h2>
      <Link to="/createstaff">Create New Staff</Link>
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Photo URL</th>
            <th>Role</th>
            <th>Mobile</th>
            <th>Email</th>
            <th>Username</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {staff.map((staff) => (
            <tr key={staff.staff_id}>
              <td>{staff.staffId}</td>
              <td>{staff.staffName}</td>
              <td>{staff.photoUrl}</td>
              <td>{staff.staffRole}</td>
              <td>{staff.staffMobile}</td>
              <td>{staff.staffEmail}</td>
              <td>{staff.staffUsername}</td>
              <td>
                <button onClick={() => handleEditStaff(staff)}>Edit</button>
                <button onClick={() => handleDeleteStaff(staff.staffId)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      {editingStaff && (
        <form onSubmit={(e) => { e.preventDefault(); handleUpdateStaff(); }}>
          <h3>Edit Staff</h3>
          <input
            type="text"
            name="staff_name"
            value={editingStaff.staffName}
            onChange={(e) => setEditingStaff({ ...editingStaff, staffName: e.target.value })}
            required
          />
          <input
            type="text"
            name="photo_url"
            value={editingStaff.photoUrl}
            onChange={(e) => setEditingStaff({ ...editingStaff, photoUrl: e.target.value })}
            required
          />
          <input
            type="text"
            name="staff_role"
            value={editingStaff.staffRole}
            onChange={(e) => setEditingStaff({ ...editingStaff, staffRole: e.target.value })}
            required
          />
          <input
            type="text"
            name="staff_mobile"
            value={editingStaff.staffMobile}
            onChange={(e) => setEditingStaff({ ...editingStaff, staffMobile: e.target.value })}
            required
          />
          <input
            type="email"
            name="staff_email"
            value={editingStaff.staffEmail}
            onChange={(e) => setEditingStaff({ ...editingStaff, staffEmail: e.target.value })}
            required
          />
          <input
            type="text"
            name="staff_username"
            value={editingStaff.staffUsername}
            onChange={(e) => setEditingStaff({ ...editingStaff, staffUsername: e.target.value })}
            required
          />
          <input
            type="password"
            name="staff_password"
            value={editingStaff.staffPassword}
            onChange={(e) => setEditingStaff({ ...editingStaff, staffPassword: e.target.value })}
            required
          />
          <button type="submit">Update</button>
        </form>
      )}
    </div>
  );
};

export default Staff;
