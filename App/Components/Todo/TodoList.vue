<template>
	<div>
		<div v-if="!isFetching">
			<div class="ui animated relaxed list" v-if="todos.length">
				<TodoListItem 
					class="item"
					v-for="todo in todos"
					:key="todo.id"
					:todo="todo"
					@remove="removeTodo"
				/>
			</div>
			<div v-else class="ui message info">
				<i class="ui icon info"></i>
				There are no todo items. Add a new todo in the input above.
			</div>
		</div>
		<div v-else class="ui clean segment empty-loader">
			<div class="ui active inverted dimmer">
				<div class="ui loader"></div>
			</div>
		</div>
	</div>
</template>

<script>
import BaseInputText from './BaseInputText.vue'
import TodoListItem from './TodoListItem.vue'
import TodoService from '../../Services/TodoService.js'

let nextTodoId = 1

export default {
	components: {
		BaseInputText, TodoListItem
	},
	data () {
		return {
			newTodoText: '',
			todos: [],
			isFetching: true
		}
	},
	methods: {
		addTodo () {
			
		},
		removeTodo (todoToRemove) {
			
		},
		getTodos() {
            this.isFetching = true
            TodoService
                .getAll()
                .then((data) => {
                    this.todos = data;
                    this.isFetching = false
                });
        }
	},
	created () {
		this.getTodos();
	}
}
</script>

<style lang="scss">
.clean.segment {
  border: 0px;
  box-shadow: none;
}
.empty-loader {
	min-height: 100px;
}
</style>