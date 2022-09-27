<template>
  <div class='auctionView'>
    <!-- {{AUCTION}} -->

    <div class="container fluid">
      <div class="columns  is-multiline">
        <div class="column is-12">
          <h4 class="title">{{AUCTION.name}}</h4>
        </div>
        <div class="column is-12 p-0">
          <div class="columns">
            <div class="image column is-4">
              <img :src="AUCTION.image" alt="" style="" class="">
            </div>
            <div class="column  is-8  p-0">
              <div class="columns is-multiline is-12 p-0">
                <div class="column is-12">
                  Ваша ставка ....
                  <input 
                  type="number" 
                  :min="MIN_STAVKA"
                  class="input" 
                  v-model="stavka">

                  <div class="button" 
                  @click="submitStavka(stavka)">Сделать ставку</div>

                  <div class="button" 
                  @click="submitStavka(MIN_STAVKA)">Ставка с минимальным шагом</div>

                  
                </div>
                <div class="column is-12 is-multiline errors" v-if="errors.length > 0">
                  <div class="column is-12 error" v-for="err in errors">
                      {{err}}
                  </div>
                </div>

<div class="column is-12">
  <h2>История ставок: </h2>
  <div class="columns is-multiline history">
    <div 
      class="column is-12 p-0" 
      v-for="st in AUCTION.history">
      {{st.size}} руб. {{USER_BY_ID()(st.idUser).name}}
    </div>
  </div>
  <h3>Начальная ставка: {{AUCTION.startStavka}}</h3>
  <h3>Шаг: {{AUCTION.stepStavka}}</h3>
</div>

<div class="column is-12">
  <h2>Описание лота:</h2>
  <div class="columns is-multiline info">
    <p>Lorem, ipsum dolor sit amet consectetur adipisicing elit. Sunt quaerat repudiandae animi nobis eum facere. Dolorum molestias consequatur iusto, odit quod, tempore provident deserunt cumque maiores, vero atque enim facilis.</p>
  </div>
</div>

              </div>
            </div>

          </div>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {
  data() {
    return {
      loaded: false,
      stavka : 0,
      errors: []
    }
  },
  components: {
  },
  computed: {
    ...mapGetters('auctions', [
      'AUCTIONS'
    ]),

    AUCTION: function () {
      let res = this.AUCTIONS.filter((item) => { if (item.id == this.$route.query.id) { return item; } });

      if (res.length == 0) {
        return {};
      }
      return res[0];
    },
    MIN_STAVKA: function () {
      return this.maxStavka() + Number(this.AUCTION.stepStavka);
    }
  },
  methods: {
    ...mapGetters('users', [
      'USER_BY_ID', 'USER'
    ]),
    ...mapActions('auctions',['auctionStavka']),

    submitStavka: function (stavka){
      this.stavka = stavka;
      this.errors = [];
      if(stavka < this.MIN_STAVKA){
        this.errors = ['Минимальная ставка: '+this.MIN_STAVKA]
        return;
      }

      this.auctionStavka({
        auctionId: this.$route.query.id,
        idUser: this.USER.id ?? 1,
        time: 0,
        size: this.stavka
      })
    },
    maxStavka: function (){
      if(this.AUCTION.history != undefined && this.AUCTION.history.length > 0)
        return this.AUCTION.history[0].size;
      else
        return this.AUCTION.startStavka;
    }
  },
  mounted() {
    if (this.$route.query.id == undefined) {
      this.$route.push({ name: 'home' })
      return;
    }

    console.log("mounted");
    this.stavka =  Number(this.maxStavka() + Number(this.AUCTION.stepStavka));
  }
}
</script>

<style lang='scss'>
.history {
  max-height: 10rem;
  overflow-y: auto;
  overflow-x: hidden;
  padding: 1rem;
  background-color: var(--color-acccent);
}
</style>
