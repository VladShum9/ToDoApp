import { useEffect, useState } from "react";
import { getAllTasks, addTask, updateTask } from '../services/ToDoTaskService';
import TaskItem from '../components/TaskItem';
import AddTaskModal from "../components/AddTaskModal";

export default function HomePage(){
    const [tasks, setTasks] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [showAddTaskModal, setShowAddTaskModal] = useState(false);

    useEffect(() => {
        const fetchTasks = async() => {
            try{
                const fetchTasks = await getAllTasks();
                setTasks(fetchTasks);
            } catch(error){
                setError("Failed to load tasks")
            } finally{
                setLoading(false);
            }
        }

        fetchTasks();
    }, []);

    const handleAddTask = () =>{
        setShowAddTaskModal(true);
    };

    const handleToggleComplete = async (task) => {
        const updatedTask = {...task, isCompleted: !task.isCompleted};

        try {
            await updateTask(updatedTask);
            setTasks(prevTasks =>
                prevTasks.map(t =>
                    t.id === updatedTask.id ? updatedTask : t
                )
            );
        } catch (error) {
            console.error("Failed to update task", error);

        }
    }

    const handleModalSubmit = async (newTask) => {
        try {
            const createdTask = await addTask(newTask);
            if (createdTask) {
                setTasks(prev => [...prev, createdTask]);
            }
        } catch (error){
            console.error("Failed to add task", error);
        }
    };

    if (loading) return <div>Loading...</div>
    if (error) return <div>{error}</div>

    return(
        <div>
            <button onClick = {handleAddTask}>Add Task</button>
            {showAddTaskModal && (
                <AddTaskModal
                    onClose={() => setShowAddTaskModal(false)}
                    onSubmit={handleModalSubmit}
                />
            )}
            <h1>Your ToDoTasks</h1>
            {
                tasks.length === 0 ? (
                    <p>No Tasks to show. Create One!</p>
                ) : (
                    <ul>
                        {tasks.map((task) => (
                            <TaskItem
                                key={task.id}
                                task={task}
                                onToggle={handleToggleComplete}
                            />
                        ))}
                    </ul>
                )
            }   
        </div>
    )
}