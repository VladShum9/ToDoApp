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
        console.log("result result", result)
        return result.data;
    } catch (error) {
        console.error("Error adding task", error);
    }
};

