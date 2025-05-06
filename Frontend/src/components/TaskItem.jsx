import React from "react";
import "./TaskItem.css";

const TaskItem = ({ task, onDelete, onToggle}) => {
    return(
        <li className="task-item">
            <span className={`task-name ${task.isCompleted ? 'completed' : ''}`}>
                {task.name}
            </span>
            <div className={`checkbox ${task.isCompleted ? 'checked' : ''}`}
            onClick={() => onToggle(task)}></div>
            <button onClick={() => onDelete(task.id)}>Delete</button>
        </li>
    )
}

export default TaskItem;