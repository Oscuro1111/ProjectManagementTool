
const BoardController = (


    dom => {

        const getById = (id) => dom.getElementById(id);

        const BoardViews = function BoardComponentViews() {
            this.column = (columnHeaderTitle, dbId,totalItems) => `<div class="kanban-column" id=PMS-Kanban-Column-${dbId}>
            <div class="kanban-column-header" id=PMS-Kanban-Column-Header-${dbId}>
                <h5 class="fs-0 mb-0">${columnHeaderTitle}<span class="text-500">(${totalItems})</span></h5>
                <div class="dropdown font-sans-serif btn-reveal-trigger">
                    <button class="btn btn-sm btn-reveal py-0 px-2" type="button" id="PMS-kanbanColumn-${dbId}" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><svg class="svg-inline--fa fa-ellipsis-h fa-w-16" aria-hidden="true" focusable="false" data-prefix="fas" data-icon="ellipsis-h" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" data-fa-i2svg=""><path fill="currentColor" d="M328 256c0 39.8-32.2 72-72 72s-72-32.2-72-72 32.2-72 72-72 72 32.2 72 72zm104-72c-39.8 0-72 32.2-72 72s32.2 72 72 72 72-32.2 72-72-32.2-72-72-72zm-352 0c-39.8 0-72 32.2-72 72s32.2 72 72 72 72-32.2 72-72-32.2-72-72-72z"></path></svg><!-- <span class="fas fa-ellipsis-h"></span> Font Awesome fontawesome.com --></button>
                    <div class="dropdown-menu dropdown-menu-end py-0" aria-labelledby="PMS-kanbanColumn-${dbId}">
                        <a class="dropdown-item" href="#!">Add Card</a><a class="dropdown-item" href="#!" id=PMS-Btn-Kanban-Column-Edit-${dbId}>Edit</a><a class="dropdown-item" href="#!" id=PMS-Btn-Kanban-Column-CopyLink-${dbId}>Copy link</a>
                        <div class="dropdown-divider"></div><a class="dropdown-item text-danger" href="#!" id=PMS-Btn-Kanban-Column-Remove-${dbId}>Remove</a>
                    </div>
                </div>      
            </div>
            <div class="kanban-items-container scrollbar" tabindex=${dbId}> 
                <form class="add-card-form mt-3" id=PMS-Kanban-Column-AddListCardForm-${dbId}>
                    <textarea class="form-control" data-input="add-card" rows="2" placeholder="Enter a title for this card..."></textarea>
                    <div class="row gx-2 mt-2">
                        <div class="col">
                            <button class="btn btn-primary btn-sm d-block w-100" type="button" id=PMS-Btn-Kanban-Column-AddCardForm-AddBtn-${dbId}>Add</button>
                        </div>
                        <div class="col">
                            <button class="btn btn-outline-secondary btn-sm d-block w-100 border-400" type="button" data-btn-form="hide" id=PMS-Btn-Kanban-Column-AddCardForm-CancelBtn-${dbId}>Cancel</button>
                        </div>
                    </div>
                </form>
            </div>
            <div class="kanban-column-footer">
                <button class="btn btn-link btn-sm d-block w-100 btn-add-card text-decoration-none text-600" type="button" id=PMS-Btn-Kanban-Column-AddAnotherCard-${dbId}><svg class="svg-inline--fa fa-plus fa-w-14 me-2" aria-hidden="true" focusable="false" data-prefix="fas" data-icon="plus" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 448 512" data-fa-i2svg=""><path fill="currentColor" d="M416 208H272V64c0-17.67-14.33-32-32-32h-32c-17.67 0-32 14.33-32 32v144H32c-17.67 0-32 14.33-32 32v32c0 17.67 14.33 32 32 32h144v144c0 17.67 14.33 32 32 32h32c17.67 0 32-14.33 32-32V304h144c17.67 0 32-14.33 32-32v-32c0-17.67-14.33-32-32-32z"></path></svg><!-- <span class="fas fa-plus me-2"></span> Font Awesome fontawesome.com -->Add another card</button>
            </div>
        </div>`;

        this.columnItem=(taskTitle,dbId)=>`
        <div class="kanban-item" tabindex="${dbId}">
                                <div class="card kanban-item-card hover-actions-trigger">
                                    <div class="card-body">
                                        <div class="position-relative">
                                            <div class="dropdown font-sans-serif">
                                                <button class="btn btn-sm btn-falcon-default kanban-item-dropdown-btn hover-actions" type="button" data-boundary="viewport" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><svg class="svg-inline--fa fa-ellipsis-h fa-w-16" data-fa-transform="shrink-2" aria-hidden="true" focusable="false" data-prefix="fas" data-icon="ellipsis-h" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" data-fa-i2svg="" style="transform-origin: 0.5em 0.5em;"><g transform="translate(256 256)"><g transform="translate(0, 0)  scale(0.875, 0.875)  rotate(0 0 0)"><path fill="currentColor" d="M328 256c0 39.8-32.2 72-72 72s-72-32.2-72-72 32.2-72 72-72 72 32.2 72 72zm104-72c-39.8 0-72 32.2-72 72s32.2 72 72 72 72-32.2 72-72-32.2-72-72-72zm-352 0c-39.8 0-72 32.2-72 72s32.2 72 72 72 72-32.2 72-72-32.2-72-72-72z" transform="translate(-256 -256)"></path></g></g></svg><!-- <span class="fas fa-ellipsis-h" data-fa-transform="shrink-2"></span> Font Awesome fontawesome.com --></button>
                                                <div class="dropdown-menu dropdown-menu-end py-0">
                                                    <a class="dropdown-item" href="#!">Add Card</a><a class="dropdown-item" href="#!">Edit</a><a class="dropdown-item" href="#!">Copy link</a>
                                                    <div class="dropdown-divider"></div><a class="dropdown-item text-danger" href="#!">Remove</a>
                                                </div>
                                            </div>
                                        </div>
                                        <p class="mb-0 fw-medium font-sans-serif stretched-link" data-bs-toggle="modal" data-bs-target="#kanban-modal-1">${taskTitle}</p>
                                    </div>
                                </div>
                            </div>
              
        `;
        }

        const ComponentsId = {
            "BoardContainer": "PMS-Kanban-Board",
            // "AddColumn":"PMS-Kanban-Board-AddColumn",
            "AddColumnWithForm": "PMS-Kanban-board-WithAddColumnForm",
            "AddColumnBtn": "PMS-Kanban-AddColumn-Btn",
            // "ShowAddColumnForm":"PMS-Kanban-ShowAddForm-Btn",
            "AddColumnForm": "PMS-Kanban-column-Form",
            "RootColumn":"PMS-Root-Column"
        };

        const Init = function () {

            const PMS_Board_State={

                dragOver:null,
                dragOverContainer:null,
                draggingSrc:null,
            };
            const boardContainer = getById(ComponentsId.BoardContainer);
            const boardAddColumnBtn = getById(ComponentsId.AddColumnBtn);

            const columnForAdd = getById(ComponentsId.AddColumnWithForm);

            const form = getById(ComponentsId.AddColumnForm);

            if (boardAddColumnBtn && boardContainer) {

                boardAddColumnBtn.addEventListener("click", function (e) {
                    e.preventDefault();
                    e.stopPropagation();
                   let views = new BoardViews();
                    let formData = new FormData(form);
                    let title = formData.get("title");

                    if (title.length== 0) {
                        alert("title cannot be empty!");
                        return;
                    }
                   boardContainer.removeChild(columnForAdd); 
                 
                  // var x =  $(rootCol).clone();
                   boardContainer.innerHTML+=views.column(title, boardContainer.children.length,boardContainer.children.length);
       
             const droppable = new Draggable.Droppable(document.querySelectorAll(".kanban-column"), {
                draggable: 'div.kanban-item',
                dropzone: 'div.kanban-items-container'
              });

              droppable.on('drag:over',(e)=>{

                 var src = e.data.originalSource;

                 var over =e.data.over;
                 var overContainer=e.data.overContainer;

                 PMS_Board_State.dragOver = over;
                 PMS_Board_State.draggingSrc = src;
                 PMS_Board_State.dragOverContainer = overContainer.children[1];
              });
              
              droppable.on('drag:stop', (e) => {

             setTimeout(()=>{
                PMS_Board_State.dragOverContainer
                         .insertBefore(PMS_Board_State.draggingSrc,PMS_Board_State.dragOver);//new ,oldChild
                    var  srcele = e.data.originalSource;
                    srcele.parentElement.className="kanban-items-container scrollbar";
                },100);
              });

                  boardContainer.appendChild(columnForAdd);
                });
            }
        }

        return {
            Init:Init
        };
    }
)(document);

BoardController.Init();