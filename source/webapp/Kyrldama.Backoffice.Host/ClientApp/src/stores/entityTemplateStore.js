import EntityService from 'services/entityService.js'
import EntityTemplateState from 'states/entityTemplateState.js'

export default class EntityTemplateStore
{
    constructor(state)
    {
        if (state)
            this.state = state
        else
            this.state = new EntityTemplateState();
        
        this.entityService = new EntityService();
    }

    async getList()
    {
        let list = await this.entityService.getEntityTemplates();
        this.state.setList(list);
    }
}