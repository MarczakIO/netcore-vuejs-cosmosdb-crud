<template>
	<div id="home">
		<h1>To-do List SPA</h1>
		<TodoList/>
	</div>
</template>

<script>
import TodoList from './Components/Todo/TodoList.vue'

export default {
	components: { TodoList }
}
</script>

<style lang="scss">
@import './variables.scss';

#home {
	max-width: 400px;
	margin: 0 auto;
	line-height: 1.4;
	font-family: 'Avenir', Helvetica, Arial, sans-serif;
	-webkit-font-smoothing: antialiased;
	-moz-osx-font-smoothing: grayscale;
	color: $vue-blue;
}

h1 {
	text-align: center;
}
</style>