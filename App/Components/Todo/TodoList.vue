<template>
	<div>
		<div v-if="!isFetching">
			<BaseInputText 
				v-model="newTodoText"
				placeholder="New todo item"
				@keydown.enter="addTodo"
				:isCreating="isCreating"
			/>
			<div class="ui animated relaxed list" v-if="todos.length">
				<TodoListItem 
					class="item"
					v-for="todo in todos"
					:key="todo.id"
					:todo="todo"
					@remove="removeTodo"
					@modify="modifyTodo"
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
			isFetching: true,
			isCreating: false
		}
	},
	methods: {
		addTodo () {
			this.isCreating = true
			var todoname = this.newTodoText.trim();
			if (todoname) {
				var todo = {"name": todoname}
				TodoService
					.create(todo)
					.then((data) => {
						this.todos.push(data);
						this.isCreating = false
						this.newTodoText = '';
					});
			} else 
				this.isCreating = false;
		},
		modifyTodo (todo, todoText) {
			this.$set(todo, 'isUpdating', true);
			TodoService
				.update(todo, todoText)
				.then((data) => {
					this.$set(todo, 'isUpdating', null);
					var index = this.todos.findIndex(todo => {
						return todo.id === data.id
					});
					this.$set(this.todos, index, data);
				});
		},
		removeTodo (todoToRemove) {
			this.$set(todoToRemove, 'isUpdating', true);
			TodoService
				.delete(todoToRemove)
				.then((data) => {
					this.todos = this.todos.filter(todo => {
						return todo.id !== todoToRemove.id
					})
					this.$set(todoToRemove, 'isUpdating', null);
				});
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