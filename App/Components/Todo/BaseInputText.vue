<template>
  <div>
    <h2>Create new todo item</h2>
    <div class="ui vertical segment">
      <div class="ui inverted dimmer" v-bind:class="{ active: isCreating }">
        <div class="ui loader"></div>
      </div>
      <input
        type="text"
        class="input"
        :value="value"
        v-on="listeners"/>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    value: {
      type: String,
      default: '',
    },
    isCreating: {
      type: Boolean,
      default: false
    }
  },
  computed: {
    listeners () {
      return {
        ...this.$listeners,
        input: event => this.$emit('input', event.target.value)
      }
    }
  }
}
</script>


<style lang="scss" scoped>
@import './App/variables.scss';

.input {
  width: 100%;
  padding: 8px 10px;
  border: 1px solid $vue-blue;
}
</style>