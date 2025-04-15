import { useEffect, useState } from "react";
import { getAllTasks } from '../services/ToDoTaskService';
import TaskItem from '../components/TaskItem';

export default function HomePage(){
    const [tasks, setTasks] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

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
        
    };

    if (loading) return <div>Loading...</div>

    if (error) return <div>{error}</div>

    return(
        <div>
            <button onClick = {handleAddTask}>Add Task</button>
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