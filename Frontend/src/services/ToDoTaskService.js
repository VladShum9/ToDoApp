import axios from "axios";

const API_URL = "https://localhost:7029/api/toDoTasks";

export const getAllTasks = async () => {
    try {
        const response = await fetch(`${API_URL}`);
        const data = await response.json();
        return data.data;
    } catch (error) {
        console.error("Error fetching tasks", error);
    };
};

export const addTask = async (taskData) => {
    try {
        const response = await fetch(`${API_URL}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(taskData)
        });
        const result = await response.json();
        return result.data;
    } catch (error) {
        console.error("Error adding task", error);
    }
};

export const updateTask = async (taskData) => {
    try {
        taskData.isComplited = false;
        const response = await fetch(`${API_URL}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(taskData)
        });
        const result = response.json();
        return result.data;
    } catch (error) {
        console.error("Error updating task", error)
    }
};

