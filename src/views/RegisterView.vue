<template>
  <div class='registerView'>
            <div class="box">
              <!-- <form> -->
                <div class="field">
                  <div class="control">
                    <input 
                    class="input is-large" 
                    type="email" 
                    placeholder="Почта" 
                    autofocus=""
                    v-model="email">
                  </div>
                </div>

<div class="field">
  <div class="control">
    <input 
    class="input is-large" 
    type="password" 
    placeholder="Пароль"
    v-model="password">
  </div>
</div>

<div class="field">
  <div class="control">
    <input 
    class="input is-large" 
    type="password" 
    placeholder="Повторите пароль"
    v-model="password2">
  </div>
</div>
                <div class="button is-block is-primary is-large is-fullwidth" 
                @click="doRegister()">Войти</div>
              <!-- </form> -->
            </div>
  </div>
</template>

<script>
  import { mapActions } from 'vuex';
export default {
  data() {
    return {
      email: "test@mail.ru" , password: "pwd", password2: "pwd"
    }
  },
  components: {},
  computed: {},
  methods: {
    ...mapActions('users', ['userRegister']),
    doregister: function  () {

      if(password2 !== password){
        return;
      }

      this.userRegister(this)
    }
  },
  mounted() { }
}
</script>

<style lang='scss'>
  .registerView{display: flex; justify-content: center;}
.registerView .box{ width:  50%;}
</style>
