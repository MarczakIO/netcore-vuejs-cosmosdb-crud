<template>
  <div class="item ui clean segment">
    <div class="ui inverted dimmer" v-bind:class="{ active: todo.isUpdating }">
      <div class="ui loader"></div>
    </div>
    <div class="right floated content">
      <button 
        class="ui button mini" v-bind:class="{ blue: !isEditing }"
        @click="isEditing = !isEditing">
        <i class="edit icon"></i>
        <span v-if="!isEditing">Edit</span>
        <span v-else>Stop editing</span>
      </button>
      <button 
        class="ui button mini red"
        @click="$emit('remove', todo)">
        <i class="remove icon"></i>
        Delete
      </button>
    </div>
    <i class="large tasks middle aligned icon"></i>
    <div class="content">
      <p class="header">{{ todo.name }}</p>
    </div>
    <div class="ui input" v-if="isEditing">
      <input
        type="text"
        class="ui input"
        v-model="newTodoText"
        @keydown.enter="modifyTodo"/>
    </div>
    
  </div>
</template>

<script>
import BaseInputText from './BaseInputText.vue'
export default {
  components: {
    BaseInputText
  },
  props: {
    todo: {
      type: Object,
      required: true
    }
  },
  data () {
		return {
      newTodoText: '',
      isEditing: false
		}
  },
  methods: {
    modifyTodo () {
      this.$emit('modify', this.todo, this.newTodoText);
      this.newTodoText = '';
    }
  }
}
</script>

<style>
.input {
  margin-top: 5px;
  width: 100%;
}
</style>
