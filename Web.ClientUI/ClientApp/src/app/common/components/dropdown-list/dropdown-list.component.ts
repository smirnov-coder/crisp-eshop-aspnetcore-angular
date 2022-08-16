import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";

export interface DropdownListItem {
    value: any;
    text: string;
}

@Component({
    selector: "dropdown-list",
    templateUrl: "dropdown-list.component.html",
    styleUrls: ["dropdown-list.component.scss"]
})
export class DropdownListComponent implements OnInit {

    @Input() items: DropdownListItem[] = [];
    @Output() selected = new EventEmitter<DropdownListItem>();
    selectedItem?: DropdownListItem;

    ngOnInit(): void {
        this.selectedItem = this.items[0];
    }

    selectedChanged() {
        this.selected.emit(this.selectedItem);
    }
}