import React, { useState, useEffect } from 'react';
import './EditBatch.css';

const EditBatch = ({ batchId, onClose }) => {
    const [batch, setBatch] = useState({
        batchName: '',
        batchStartDate: '',
        batchEndDate: '',
        courseId: '',
        finalPresentationDate: '',
        batchFees: '',
        courseFeesFrom: '',
        courseFeesTo: '',
        batchIsActive: false,
    });

    const [courses, setCourses] = useState([]);

    useEffect(() => {
        // Fetch batch details
        fetch(`http://localhost:5051/api/Batch/${batchId}`)
            .then(response => response.json())
            .then(data => setBatch(data))
            .catch(error => console.error('Error fetching batch details:', error));

        // Fetch courses for dropdown
        fetch('http://localhost:5051/api/Courses')
            .then(response => response.json())
            .then(data => setCourses(data))
            .catch(error => console.error('Error fetching courses:', error));
    }, [batchId]);

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setBatch(prevState => ({
            ...prevState,
            [name]: type === 'checkbox' ? checked : value
        }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        fetch(`http://localhost:5051/api/Batch/${batch.batchId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(batch),
        })
            .then(response => {
                if (response.ok) {
                    alert('Batch updated successfully!');
                    onClose(); // Close the form after successful update
                } else {
                    return response.json().then(error => {
                        throw new Error(error.message);
                    });
                }
            })
            .catch(error => console.error('Error updating batch:', error));
    };

    return (
        <div className="edit-batch-container">
            <h2>Edit Batch</h2>
            <form onSubmit={handleSubmit}>
                <div className="form-group">
                    <label>Batch Name:</label>
                    <input
                        type="text"
                        name="batch_name"
                        value={batch.batchName}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Batch Start Date:</label>
                    <input
                        type="date"
                        name="batch_start_date"
                        value={batch.batchStartDate} // Remove time part
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Batch End Date:</label>
                    <input
                        type="date"
                        name="batch_end_date"
                        value={batch.batchEndDate} // Remove time part
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Course:</label>
                    <select
                        name="course_id"
                        value={batch.courseId}
                        onChange={handleChange}
                        required
                    >
                        <option value="">Select a Course</option>
                        {courses.map(course => (
                            <option key={course.course_id} value={course.course_id}>
                                {course.courseName}
                            </option>
                        ))}
                    </select>
                </div>
                <div className="form-group">
                    <label>Final Presentation Date:</label>
                    <input
                        type="date"
                        name="final_presentation_date"
                        value={batch.finalPresentationDate ? batch.finalPresentationDate : ''}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>Batch Fees:</label>
                    <input
                        type="number"
                        name="batch_fees"
                        value={batch.batchFees}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Course Fees From:</label>
                    <input
                        type="date"
                        name="course_fees_from"
                        value={batch.courseFeesFrom ? batch.courseFeesFrom : ''}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>Course Fees To:</label>
                    <input
                        type="date"
                        name="course_fees_to"
                        value={batch.courseFeesTo ? batch.courseFeesTo : ''}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>Active:</label>
                    <input
                        type="checkbox"
                        name="batch_is_active"
                        checked={batch.batchIsActive}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-actions">
                    <button type="submit">Save</button>
                    <button type="button" onClick={onClose}>Cancel</button>
                </div>
            </form>
        </div>
    );
};

export default EditBatch;
