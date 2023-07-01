import EntityService from 'services/entityService.js'
import PromptState from 'states/promptState.js'

export default class PromptStore
{
    constructor(state)
    {
        if (state)
            this.state = state
        else
            this.state = new PromptState();
        
        this.entityService = new EntityService();
    }

    async getList()
    {
        let list = await this.entityService.getPrompts();
        this.state.setList(list);
    }
}