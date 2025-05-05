import { useEffect, useState } from "react";
import { getAllTasks, addTask } from '../services/ToDoTaskService';
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
                            />
                        ))}
                    </ul>
                )
            }   
        </div>
    )
}