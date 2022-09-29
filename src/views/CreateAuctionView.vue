<template>
  <div class='createAuction card p-6 form'>
    <div class="field" v-if="this.errors == true">
      <article class="message is-danger">
        <div class="message-header">
          <p>Неверный формат данных</p>
          <button class="delete" aria-label="delete" v-on:click="this.errors = false"></button>
        </div>
      </article>
    </div>

    <div class="field">
      <label class="label ">Название аукциона</label>
      <div class="field ">
        <div class="control">
          <input class="input" type="text" v-model="name">
        </div>
      </div>
    </div>

    <div class="field">
      <label class="label ">Введите ссылку на превью лота</label>
      <div class="field has-addons ">
        <div class="field-label is-normal">
          <label class="label ">Ссылка: </label>
        </div>
        <div class="control">
          <input class="input" type="text" v-model="uri">
        </div>
      </div>
    </div>

    <div class="field">
      <label class="label ">Настройка цены</label>

      <div class="field has-addons ">
        <div class="field-label is-normal">
          <label class="label ">Начальная строимость: </label>
        </div>
        <div class="control">
          <input class="input" type="number" v-model="size_min">
        </div>
      </div>

      <div class="field has-addons ">
        <div class="field-label is-normal">
          <label class="label ">Шаг: </label>
        </div>
        <div class="control">
          <input class="input" type="text" v-model="size_step">
        </div>
      </div>
    </div>

    <div class="field">
      <label class="label">Длительность аукциона: </label>
      <p class="control">
        <span class="select">
          <select v-model="duration">
            <option value="1">1 день</option>
            <option value="3">3 дня</option>
            <option value="7">7 дней</option>
          </select>
        </span>
      </p>
    </div>

    <div class="field">
      <label class="label ">Описание лота: </label>

      <div class="field">
        <div class="control">
          <textarea class="" type="text" v-model="description" rows="4"></textarea>
        </div>
      </div>

    </div>

    <div class="button is-block is-primary is-large is-fullwidth" 
                @click="doCreate()">Выставить аукцион</div>

  </div>
</template>

<script>
import { mapActions, mapGetters } from 'vuex'

export default {
  data() {
    return {
      errors: false,
      name: 'Новый аукцион',
      uri: '',
      size_min: 0,
      size_step: 10,
      duration: 1,
      description: ''
    }
  },
  components: {},
  computed: {},
  methods: {
    ...mapGetters('users', ['USER']),
    ...mapActions('auctions', ['auctionAdd', 'auctionList']),
    
    isNumber(n){
      return typeof n == 'number' && !isNaN(n) && isFinite(n);
    },
    doCreate: function (){
      
      if(this.size_min < 0 || !this.isNumber(this.size_min)){
        this.errors = true;
        return;
      }
      
      if(this.size_step < 0 || !this.isNumber(this.size_step)){
        this.errors = true;
        return;
      }

      let data = {
        name: this.name,
        idUser: this.USER().id,
        image: this.uri,
        timeStart: Date.now(),
        timeEnd: Date.now() + (60*60*24 * this.duration)*1000 ,
        startStavka: this.size_min,
        stepStavka: this.size_step,
        description: this.description
      };

      this.auctionAdd(data).then((response)=>{

        if(response != true){
          this.errors = true;
          return;
        }

        this.auctionList().then(()=>{
          this.$router.push({ name: 'home' })
        });        
      });
    }
  },
  mounted() { }
}
</script>

<style lang='scss'>

</style>
