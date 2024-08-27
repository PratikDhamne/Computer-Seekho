import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import './CreateCourse.css';

const CreateCourse = () => {
  const [course, setCourse] = useState({
    courseName: '',
    courseDescription: '',
    courseDuration: '',
    courseSyllabus: '',
    ageGrpType: '',
    courseIsActive: false,
    coverPhoto: ''
  });
  const navigate = useNavigate();

  const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setCourse(prevState => ({
      ...prevState,
      [name]: type === 'checkbox' ? checked : value
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await fetch('http://localhost:5051/api/Courses', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(course),
      });
      navigate('/manipulate');
    } catch (error) {
      console.error('Error creating course:', error);
    }
  };

  return (
    <div className="create-course-container">
      <h1>Create New Course</h1>
      <form onSubmit={handleSubmit}>
        <label>
          Course Name:
          <input type="text" name="course_name" value={course.courseName} onChange={handleChange} required />
        </label>
        <label>
          Description:
          <input type="text" name="course_description" value={course.courseDescription} onChange={handleChange} required />
        </label>
        <label>
          Duration (hours):
          <input type="number" name="course_duration" value={course.courseDuration} onChange={handleChange} required />
        </label>
        <label>
          Syllabus:
          <input type="text" name="course_syllabus" value={course.courseSyllabus} onChange={handleChange} required />
        </label>
        <label>
          Age Group:
          <input type="text" name="age_grp_type" value={course.ageGrpType} onChange={handleChange} required />
        </label>
        <label>
          Active:
          <input type="checkbox" name="course_is_active" checked={course.courseIsActive} onChange={handleChange} />
        </label>
        <label>
          Cover Photo URL:
          <input type="text" name="cover_photo" value={course.coverPhoto} onChange={handleChange} />
        </label>
        <button type="submit">Create Course</button>
      </form>
    </div>
  );
};

export default CreateCourse;
