import { useEffect, useState } from "react";
import ToDoTaslService from "../services/ToDoTaskService"

export default function HomePage(){
    const [tasks, setTasks] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchTasks = async() => {
            try{
                const fetchTasks = await ToDoTaskService.getAllTasks();
                setTasks(fetchTasks);
            } catch(error){
                setError("Failed to load tasks")
            } finally{
                setLoading(false);
            }
        }

        fetchTasks();
    }, []);

    if (loading) return <div>Loading...</div>

    if (error) return <div>{error}</div>

    return(
        <div>
            <h1>Your ToDoTasks</h1>
            {
                tasks.length === 0 ? (
                    <p>No Tasks to show. Create One!</p>
                ) : (
                    <ul>
                        {tasks.map((task) => (
                            <li key ={task.id}>{task.name}</li>
                        ))}
                    </ul>
                )
            }
        </div>
    )
}