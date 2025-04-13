import React from "react";
import "./TaskItem.css";

const TaskItem = ({ task, onDelete, onToggle}) => {
    return(
        <li className="task-item">
            <span className={`task-name ${task.isCompleted ? 'completed' : ''}`}>
                {task.name}
            </span>
            <div className={`checkbox ${task.isCompleted ? 'checked' : ''}`}></div>
        </li>
    )
}

export default TaskItem;