import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import './CreateBatch.css';

const CreateBatch = ({ onClose }) => {
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
    const navigate = useNavigate();

    useEffect(() => {
        fetch('http://localhost:5051/api/Courses')
            .then(response => response.json())
            .then(data => setCourses(data))
            .catch(error => console.error('Error fetching courses:', error));
    }, []);

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setBatch(prevState => ({
            ...prevState,
            [name]: type === 'checkbox' ? checked : value
        }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();

        // Ensure course_id is an integer if that's what's expected
        const batchData = {
            ...batch,
            course_id: parseInt(batch.courseId, 10) // Assuming course_id should be an integer
        };

        fetch('http://localhost:5051/api/Batch', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(batchData),
        })
            .then(response => {
                if (response.ok) {
                    alert('Batch created successfully!');
                } else {
                    return response.json().then(error => {
                        throw new Error(error.message);
                    });
                }
            })
            .catch(error => console.error('Error creating batch:', error));

            navigate('/manipulate');
    };

    return (
        <div className="create-batch-container">
            <h2>Create Batch</h2>
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
                        value={batch.batchStartDate}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Batch End Date:</label>
                    <input
                        type="date"
                        name="batch_end_date"
                        value={batch.batchEndDate}
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
                            <option key={course.course_id?.courseId} value={course.course_id?.courseId}>
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
                        value={batch.finalPresentationDate}
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
                        value={batch.courseFeesFrom}
                        onChange={handleChange}
                    />
                </div>
                <div className="form-group">
                    <label>Course Fees To:</label>
                    <input
                        type="date"
                        name="course_fees_to"
                        value={batch.courseFeesTo}
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
                    <button type="submit">Create</button>
                    <button type="button" onClick={onClose}>Cancel</button>
                </div>
            </form>
        </div>
    );
};

export default CreateBatch;
