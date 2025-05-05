import React from 'react';

export default function AddTaskModal({onClose, onSubmit}) {
    const handleSubmit = (e) => {
        e.preventDefault();
        const form = e.target;
        const newTask = {
            id: "a",
            name: form.name.value,
            isCompleted: false,
            applicationUserId: "1462e284-fe12-42bb-a446-75fc275e618d"
        }
        onSubmit(newTask);
        onClose();
    }

    return (
        <div className='modal-block'>
            <div className="modal-content">
                <h2>Add new Task</h2>
                <form onSubmit={handleSubmit}>
                    <label>
                        Title:
                        <input name="name" required />
                    </label>
                    <label>
                        Description:
                        <textarea name="description" />
                    </label>
                    <button type="submit">Save</button>
                    <button type="button" onClick={onClose}>Cancel</button>
                </form>
            </div>
        </div>
    )
}