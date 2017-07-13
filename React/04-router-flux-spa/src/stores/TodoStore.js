import { EventEmitter } from 'events';

import dispatcher from '../dispatcher';

class TodoStore extends EventEmitter {
    constructor() {
        super();
        this.todos = [
            {
                id: 123123123,
                text: "Go Shopping",
                complete: false
            },
            {
                id: 13213123,
                text: "Pay Water Bill",
                complete: false
            }
        ];
    }

    createTodo(text) {
        this.todos.push({
            id: Date.now(),
            text,
            complete: false
        })

        this.emit("change");
    }

    getAll() {
        return this.todos;
    }

    handleActons(action) {
        switch (action.type) {
            case "CREATE_TODO":
                this.createTodo(action.text);
                break;
            case "RECEIVE_TODOS":
                this.todos = action.todos;
                this.emit("change");
                break;
            default:
                break;
        }
        console.log("TodoStore recieved an action", action);
    }
}

const todoStore = new TodoStore();

dispatcher.register(todoStore.handleActons.bind(todoStore));

window.todoStore = todoStore;
window.dispatcher = dispatcher;

export default todoStore;