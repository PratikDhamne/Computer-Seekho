import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import './Courses.css';

const fetchData = async (endpoint) => {
  const response = await fetch(endpoint);
  if (!response.ok) {
    throw new Error('Network response was not ok');
  }
  return response.json();
};

const Course = () => {
  const [courses, setCourses] = useState([]);
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchCourses = async () => {
      try {
        const data = await fetchData('http://localhost:5051/api/Courses');
        setCourses(data);
      } catch (error) {
        console.error('Error fetching data:', error);
      } finally {
        setLoading(false);
      }
    };

    fetchCourses();
  }, []);

  const handleDelete = async (courseId) => {
    if (window.confirm('Are you sure you want to delete this course?')) {
      try {
        await fetch(`http://localhost:5051/api/Courses/${courseId}`, {
          method: 'DELETE',
        });
        setCourses(courses.filter(course => course.courseId !== courseId));
      } catch (error) {
        console.error('Error deleting course:', error);
      }
    }
  };

  const handleEdit = (courseId) => {
    navigate(`/edit-course/${courseId}`);
  };

  const handleCreate = () => {
    navigate('/create-course');
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="course-crud-container">
      <h1>Course Management</h1>
      <button className="create-course-button" onClick={handleCreate}>Create New Course</button>
      <table className="course-table">
        <thead>
          <tr>
            <th>Name</th>
            <th>Description</th>
            <th>Duration</th>
            <th>Syllabus</th>
            <th>Age Group</th>
            <th>Active</th>
            <th>Cover Photo</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {courses.map(course => (
            <tr key={course.courseId}>
              <td>{course.courseName}</td>
              <td>{course.courseDescription}</td>
              <td>{course.courseDuration}</td>
              <td>{course.courseSyllabus}</td>
              <td>{course.ageGrpType}</td>
              <td>{course.courseIsActive ? 'Yes' : 'No'}</td>
              <td><img src={course.coverPhoto} alt="Cover" className="cover-photo" /></td>
              <td>
                <button onClick={() => handleEdit(course.courseId)}>Edit</button>
                <button onClick={() => handleDelete(course.courseId)}>Delete</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Course;
