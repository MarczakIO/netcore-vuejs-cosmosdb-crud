<template>
  <div class="item ui clean segment">
    <div class="ui dimmer" v-bind:class="{ active: todo.isUpdating }">
      <div class="ui loader"></div>
    </div>
    <div class="right floated content">
      <button 
        class="ui button mini"
        @click="$emit('remove', todo)">
        <i class="remove icon"></i>
        Delete
      </button>
    </div>
    <i class="large tasks middle aligned icon"></i>
    <div class="content">
      <h3 class="header">{{ todo.name }}</h3>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    todo: {
      type: Object,
      required: true
    }
  }
}
</script>

